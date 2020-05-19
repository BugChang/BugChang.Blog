<template>
  <v-card>
    <v-card-title> 添加评论</v-card-title>
    <v-card-text class="pb-0">
      <v-form v-model="valid">
        <v-row dense>
          <v-col cols="12" md="6">
            <v-text-field
              v-model="comment.nickName"
              label="昵称"
              :rules="[(v) => !!v || '昵称不能为空']"
              filled
            ></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <v-text-field
              v-model="comment.email"
              label="邮箱"
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
      comment: {
        userId: null,
        postId: this.postId,
        email: '',
        nickName: '',
        content: '',
        isNotice: false,
        replyId: 0,
      },
      emailRules: [
        (v) => !!v || '邮箱地址不能为空',
        (v) => /.+@.+\..+/.test(v) || '邮箱地址格式不正确',
      ],
    }
  },
  methods: {
    async commit() {
      const data = await this.$axios.$post('/posts/comments', this.comment)
      console.log(this.comment)
      console.log(data)
    },
  },
}
</script>
