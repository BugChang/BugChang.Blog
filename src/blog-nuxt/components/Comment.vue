<template>
  <div>
    <v-card>
      <v-card-title>评论列表</v-card-title>
      <v-card-text>
        <span v-if="comments.length === 0">暂无评论...</span>
        <v-list v-else three-line>
          <template v-for="(item, i) in comments">
            <v-list-item :key="item.id">
              <v-list-item-avatar color="primary" class="white--text">
                {{ item.nickName.substring(0, 1) }}
              </v-list-item-avatar>

              <v-list-item-content>
                <v-list-item-title
                  ><strong>{{ item.nickName }}</strong>
                  <span class="caption"> {{ item.createTime }}</span>
                </v-list-item-title>
                <!-- eslint-disable-next-line vue/no-v-html -->
                <v-list-item-subtitle v-html="item.content">
                </v-list-item-subtitle>
              </v-list-item-content>
            </v-list-item>
            <v-divider
              v-if="i != comments.length - 1"
              :key="`d${i}`"
              inset
            ></v-divider>
          </template>
        </v-list>
        <v-pagination
          v-if="comments.length !== 0"
          v-model="page"
          :length="pageCount"
          @input="getCommnets()"
        ></v-pagination>
      </v-card-text>
    </v-card>
    <v-card class="mt-4">
      <v-card-title> 添加评论</v-card-title>
      <v-card-text class="pb-0">
        <v-form ref="form" v-model="valid">
          <v-row dense>
            <v-col v-if="currentUser == null" cols="12" md="6">
              <v-text-field
                v-model="comment.nickName"
                label="昵称"
                :rules="[(v) => !!v || '昵称不能为空']"
                filled
              ></v-text-field>
            </v-col>
            <v-col v-if="currentUser == null" cols="12" md="6">
              <v-text-field
                v-model="comment.email"
                label="邮箱"
                hint="邮箱不会公开显示"
                :rules="emailRules"
                filled
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-textarea
                v-model="comment.content"
                filled
                auto-grow
                rows="3"
                label="内容"
                :rules="[(v) => !!v || '内容不能为空']"
              ></v-textarea>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-checkbox
          v-model="comment.isNotice"
          class="mr-2 my-auto"
          hide-details
          label="有新回复邮件通知我"
        ></v-checkbox>
        <v-btn class="primary" @click="commit">提交</v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script>
export default {
  props: {
    postId: {
      type: Number,
      default() {
        return 0
      },
    },
  },
  data() {
    return {
      valid: true,
      page: 1,
      pageCount: 1,
      comment: {
        userId: null,
        postId: this.postId,
        email: '',
        nickName: '',
        content: '',
        isNotice: false,
        replyId: null,
      },
      comments: [],
      emailRules: [
        (v) => !!v || '邮箱地址不能为空',
        (v) => /.+@.+\..+/.test(v) || '邮箱地址格式不正确',
      ],
    }
  },
  computed: {
    currentUser() {
      return this.$store.state.currentUser
    },
  },
  created() {
    this.getCommnets()
  },
  methods: {
    async commit() {
      if (this.validate()) {
        await this.$axios.$post('/posts/comments', this.comment)
        await this.getCommnets()
        Object.assign(this.comment, this.$options.data().comment)
        this.comment.postId = this.postId
        this.$refs.form.resetValidation()
      }
    },
    async getCommnets() {
      const data = await this.$axios.$get(
        `/posts/${this.postId}/comments?page=${this.page}`
      )
      this.comments = data.records
      this.pageCount = data.pageCount
      this.page = data.page
    },
    validate() {
      return this.$refs.form.validate()
    },
  },
}
</script>
