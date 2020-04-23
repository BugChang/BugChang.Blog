<style scoped>
.exception-content {
  padding-left: 65px;
}
</style>
<template>
  <v-container fluid style="margin-top: 5%;">
    <v-row align="center" justify="center">
      <v-col cols="12" md="6" class="exception-content" order-md="2">
        <div class="display-4 font-weight-medium">404</div>
        <div class="title grey--text">
          {{ calcErrorMessage(error.statusCode) }}
        </div>
        <v-btn class="mt-2" tile color="primary" to="/">返回首页</v-btn>
      </v-col>
      <v-col cols="12" md="6" order-md="1">
        <v-img
          class="float-right"
          :src="`/image/${error.statusCode}.svg`"
          max-width="430px"
          width="100%"
        ></v-img>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  layout: null,
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
  methods: {
    calcErrorMessage(statusCode) {
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
  },
  head() {
    const title = this.calcErrorMessage(this.error.statusCode)
    return {
      title,
    }
  },
}
</script>

<style scoped>
h1 {
  font-size: 20px;
}
</style>
