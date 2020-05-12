<template>
  <v-container>
    <v-breadcrumbs class="pl-0" :items="breadcrumbs"></v-breadcrumbs>
    <PostPreview
      v-for="post in posts"
      :key="post.id"
      :post="post"
      class="mb-4 align-self-center"
      style="width: 100%;"
    />
    <div class="text-center">
      <v-pagination
        v-model="page"
        :length="pageCount"
        @input="jump"
      ></v-pagination>
    </div>
  </v-container>
</template>
<script>
import PostPreview from '@/components/PostPreview'
export default {
  components: { PostPreview },
  async asyncData({ params, $axios }) {
    const tagName = params.name
    const breadcrumbs = [
      {
        text: '首页',
        disabled: false,
        to: '/',
        exact: true,
      },
      {
        text: '标签',
        disabled: false,
        to: '/tag',
        exact: true,
      },
      {
        text: tagName,
        disabled: true,
        to: '',
        exact: true,
      },
    ]
    const data = await $axios.$get(`/tags/${encodeURI(tagName)}/posts`)
    return {
      tagName,
      breadcrumbs,
      posts: data.records,
      page: data.page,
      pageCount: data.pageCount,
    }
  },
  methods: {
    jump() {},
  },
  head() {
    return {
      title: `标签 | ${this.tagName}`,
      meta: [
        {
          hid: 'description',
          name: 'description',
          content:
            "BugChang's Blog,个人博客,前后端分离博客,nuxt博客,.net core博客,BugChang的博客,BugChang,博客",
        },
      ],
    }
  },
}
</script>
