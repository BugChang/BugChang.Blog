<template>
  <div>
    <v-menu offset-y max-width="160">
      <template v-slot:activator="{ on }">
        <v-btn icon color="primary" v-on="on">
          <v-icon>mdi-share-variant</v-icon>
        </v-btn>
      </template>
      <v-list dense>
        <v-list-item
          class="copy"
          data-clipboard-text="Just because you can doesn't mean you should — clipboard.js"
          @click="copyLink"
        >
          <v-list-item-title>
            <v-icon left>mdi-link</v-icon>
            复制链接</v-list-item-title
          >
        </v-list-item>
        <v-list-item @click="weibo">
          <v-list-item-title
            ><v-icon left>mdi-sina-weibo</v-icon>新浪微博</v-list-item-title
          >
        </v-list-item>
        <v-list-item dense>
          <v-list-item-title>
            <v-icon left>mdi-wechat</v-icon>微信扫一扫</v-list-item-title
          >
        </v-list-item>
        <v-list-item>
          <v-img
            :src="`https://www.kuaizhan.com/common/encode-png?large=true&data=http://www.bugchang.com/post/${postId}`"
            width="160"
          ></v-img>
        </v-list-item>
      </v-list>
    </v-menu>
    <v-snackbar v-model="snackbar" color="success" right top :timeout="1000">
      链接复制成功！
    </v-snackbar>
  </div>
</template>
<script>
import Clipboard from 'clipboard'

export default {
  props: {
    postId: {
      type: Number,
      required: true,
    },
    title: {
      type: String,
      required: true,
    },
  },
  data: () => {
    return { snackbar: false }
  },
  mounted() {},
  methods: {
    copyLink() {
      const vm = this
      const clipboard = new Clipboard('.copy', {
        text() {
          return `【BugChang's Blog】${vm.title}\r\nhttp://www.bugchang.com/post/${vm.postId}`
        },
      })
      clipboard.on('success', function (e) {
        vm.showSuccess()
      })
    },
    showSuccess() {
      this.snackbar = true
    },
    weibo() {},
  },
}
</script>
