<template>
  <v-container fluid class="pa-0 ma-0">
    <v-row class="ma-0">
      <v-col cols="7" class="pa-0 left d-none d-md-flex">
        <v-card class="left-card" color="transparent" tile flat height="100vh">
          <img src="/image/bg-login.svg" />
          <v-card-title>
            <span class="display-2 white--text text-center" style="width: 100%;"
              >Thoughts, stories and ideas.</span
            >
          </v-card-title>
        </v-card>
      </v-col>
      <v-col cols="12" class="pa-0 right" md="5">
        <v-card tile flat class="right-card" color="transparent">
          <v-avatar>
            <img src="/image/logo160x160.png" />
          </v-avatar>
          <span class="display-1">
            BugChang's Blog
          </span>
          <v-card-title>
            <div class="login-title">
              <span class="headline">登录</span>&nbsp;没有账号? &nbsp;<nuxt-link
                to="/register"
                >注册</nuxt-link
              >
            </div>
          </v-card-title>
          <v-card-text>
            <v-form ref="form" v-model="valid">
              <v-text-field
                v-model="loginInfo.usernameOrEmail"
                label="请输入用户名或邮箱"
                :rules="[(v) => !!v || '字段不能为空']"
                outlined
              ></v-text-field>
              <v-text-field
                v-model="loginInfo.password"
                label="请输入密码"
                type="password"
                :rules="[(v) => !!v || '字段不能为空']"
                outlined
              ></v-text-field>
              <span v-show="error" class="error--text mb-4">{{
                errorMsg
              }}</span>
              <v-checkbox
                v-model="loginInfo.rememberMe"
                label="记住我"
              ></v-checkbox>

              <v-btn
                block
                color="primary"
                :loading="loading"
                @click.stop="login"
              >
                登录
              </v-btn>
            </v-form>
            <v-divider class="mt-4"></v-divider>
            <v-subheader class="pl-0">使用其他方式登录</v-subheader>
            <v-btn icon>
              <v-icon>mdi-github</v-icon>
            </v-btn>
            <v-btn icon>
              <v-icon>mdi-wechat</v-icon>
            </v-btn>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import md5 from 'js-md5'
const Cookie = process.client ? require('js-cookie') : undefined
export default {
  asyncData({ query }) {
    let returnUrl = '/'
    if (query.returnUrl) {
      returnUrl = query.returnUrl
    }
    return { returnUrl }
  },
  layout: 'blank',
  data: () => {
    return {
      valid: true,
      loading: false,
      loginInfo: {
        usernameOrEmail: '',
        password: '',
        rememberMe: false,
      },
      error: false,
      errorMsg: '',
    }
  },
  methods: {
    async login() {
      this.loading = true
      if (this.validate()) {
        this.loginInfo.password = md5(this.loginInfo.password)
        try {
          const token = await this.$axios.$post(`/token`, this.loginInfo)
          Cookie.set('token', token, { expires: 365 })
          this.$store.commit('setToken', token)
          await this.getCurrentUser()
          this.$router.push(this.returnUrl)
        } catch (err) {
          this.showError(err.response.data.error)
        }
      }
      this.loading = false
    },
    showError(message) {
      this.errorMsg = message
      this.error = true
    },
    validate() {
      return this.$refs.form.validate()
    },
    async getCurrentUser() {
      const currentUser = await this.$axios.$get('/accounts')
      Cookie.set('currentUser', currentUser, { expires: 365 })
      this.$store.commit('setUserInfo', currentUser)
    },
  },
  head() {
    return {
      title: `登录`,
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
<style scoped>
.left {
  background: linear-gradient(#e91e63, #f48fb1);
}

.left-card {
  width: 100%;
  max-width: 560px;
  margin: 0 auto;
}
.right-card {
  width: 100%;
  max-width: 560px;
  margin: 120px auto;
}
.login-title {
  font-size: 16px;
}

.login-title a {
  text-decoration: none;
}
</style>
