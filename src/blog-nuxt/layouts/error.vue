<style scoped>
.exception-content {
  padding-left: 65px;
}
</style>
<template>
  <v-container fluid style="margin-top: 5%;">
    <v-row align="center" justify="center">
      <v-col cols="12" md="6" class="exception-content" order-md="2">
        <div class="display-4 font-weight-medium">{{ error.statusCode }}</div>
        <div class="title grey--text">
          {{ errorMessage }}
        </div>
        <v-btn class="mt-2" tile color="primary" :to="returnUrl"
          >返回首页</v-btn
        >
        <v-btn v-if="error.statusCode !== 404" class="mt-2" tile @click="reload"
          ><v-icon>mdi-refresh</v-icon>重载</v-btn
        >
      </v-col>
      <v-col cols="12" md="6" order-md="1">
        <v-img
          class="float-right"
          :src="`/image/${imgName}.svg`"
          max-width="430px"
          width="100%"
        ></v-img>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  layout({ route }) {
    if (route.fullPath.includes('/admin')) {
      return 'admin'
    }
    return 'default'
  },
  props: {
    error: {
      type: Object,
      default: null,
    },
  },

  data() {
    return {
      pageNotFound: '抱歉，你访问的页面不存在或仍在开发中',
      noAccess: '抱歉，你无权访问该页面',
      otherError: '抱歉，服务器出错了',
    }
  },
  computed: {
    errorMessage() {
      if (this.error.customMessage) {
        return this.error.message
      }
      const statusCode = this.error.statusCode
      let errorMessage
      switch (statusCode) {
        case 403:
          errorMessage = this.noAccess
          break
        case 404:
          errorMessage = this.pageNotFound
          break
        default:
          errorMessage = this.otherError
          break
      }
      return errorMessage
    },
    imgName() {
      const statusCode = this.error.statusCode
      switch (statusCode) {
        case 403:
        case 404:
          return statusCode
        default:
          return 500
      }
    },
    returnUrl() {
      let url = '/'
      if (process.client) {
        if (window.location.pathname.includes('/admin')) {
          url = '/admin'
        }
      }
      return url
    },
  },
  methods: {
    reload() {
      if (process.client) {
        location.reload()
      }
    },
  },
  head() {
    const title = this.errorMessage
    return {
      title,
    }
  },
}
</script>
