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
              <span class="headline">注册</span>&nbsp;已有账号? &nbsp;<nuxt-link
                to="/login"
                >登录</nuxt-link
              >
            </div>
          </v-card-title>
          <v-card-text>
            <v-form ref="form">
              <v-text-field label="邮箱" outlined></v-text-field>
              <v-text-field label="用户名" outlined></v-text-field>
              <v-text-field
                label="密码"
                type="password"
                outlined
              ></v-text-field>
              <v-text-field
                label="确认密码"
                type="password"
                outlined
              ></v-text-field>
              <v-checkbox>
                <template v-slot:label>
                  我已阅读并同意
                  <a href="/agreement" target="_blank" @click.stop
                    >《注册协议》</a
                  >和
                  <a href="/privacypolicy" target="_blank" @click.stop
                    >《隐私政策》</a
                  >
                </template>
              </v-checkbox>
              <v-btn block color="primary">
                注册
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
export default {
  layout: 'blank',
  methods: {},
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

a {
  text-decoration: none;
}
</style>
