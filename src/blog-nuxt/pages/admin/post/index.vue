<template>
  <v-container fluid>
    <v-data-table :headers="headers" :items="posts" class="elevation-1">
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>所有文章</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn color="primary" to="/admin/post/write">写文章</v-btn>
        </v-toolbar>
      </template>
      <!-- 分类插槽 -->
      <template v-slot:item.categoryId="{ item }">
        <v-chip small dark :color="item.categoryColor">{{
          item.categoryName
        }}</v-chip>
      </template>
      <!-- 封面插槽 -->
      <template v-slot:item.coverImgUrl="{ item }">
        <a
          v-if="item.coverImgUrl"
          text
          color="primary"
          @click.stop="coverImgPreview(item.coverImgUrl)"
        >
          预览
        </a>
      </template>
      <!-- 发布插槽 -->
      <template v-slot:item.isPublish="{ item }">
        <v-switch v-model="item.isPublish" readonly dense></v-switch>
      </template>
      <!-- 置顶插槽 -->
      <template v-slot:item.isSticky="{ item }">
        <v-switch v-model="item.isSticky" readonly dense></v-switch>
      </template>
      <!-- 标签插槽 -->
      <template v-slot:item.tags="{ item }">
        <span v-for="tag in item.tags" :key="tag">
          {{ tag }}
        </span>
      </template>
      <!-- 操作插槽 -->
      <template v-slot:item.actions="{ item }">
        <v-btn icon class="mr-2" :to="`/admin/post/write/${item.id}`">
          <v-icon small>mdi-pencil</v-icon>
        </v-btn>
        <v-btn icon class="mr-2" @click="deletePost(item.id)">
          <v-icon small>mdi-delete</v-icon>
        </v-btn>
      </template>
      <!-- 无数据插槽 -->
      <template v-slot:no-data>
        <v-btn color="primary" @click="getPosts()">
          <v-icon>mdi-refresh</v-icon>
          刷新一下</v-btn
        >
      </template>
    </v-data-table>
    <!-- 图片预览Dialog -->
    <v-dialog v-model="coverImgDialog" max-width="800" width="80%">
      <v-img :src="coverImgUrl"></v-img>
    </v-dialog>
  </v-container>
</template>
<script>
export default {
  layout: 'admin',
  data: () => {
    return {
      coverImgDialog: false,
      posts: [],
      headers: [
        { text: '主键', value: 'id' },
        { text: '标题', value: 'title' },
        { text: '分类', value: 'categoryId' },
        { text: '封面', value: 'coverImgUrl' },
        { text: '发布', value: 'isPublish' },
        { text: '置顶', value: 'isSticky' },
        { text: '标签', value: 'tags' },
        { text: '点击量', value: 'viewCount' },
        { text: '创建时间', value: 'createTime' },
        { text: '操作', value: 'actions' },
      ],
      coverImgUrl: '',
    }
  },
  created() {
    this.getPosts()
  },
  methods: {
    async getPosts() {
      this.posts = await this.$axios.$get('/posts')
    },
    deletePost(postId) {},
    coverImgPreview(coverImgUrl) {
      this.coverImgUrl = coverImgUrl
      this.coverImgDialog = true
    },
  },
}
</script>
