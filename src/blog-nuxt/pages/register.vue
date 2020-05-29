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
          <span class="display-1">BugChang's Blog</span>
          <v-card-title>
            <div class="login-title">
              <span class="headline">注册</span>&nbsp;已有账号? &nbsp;
              <nuxt-link to="/login">登录</nuxt-link>
            </div>
          </v-card-title>
          <v-card-text>
            <v-form ref="form" v-model="valid">
              <v-text-field
                v-model="registerInfo.email"
                :rules="emailRules"
                label="邮箱"
                outlined
              ></v-text-field>
              <v-text-field
                v-model="registerInfo.userName"
                label="用户名"
                outlined
                :rules="userNameRules"
              ></v-text-field>
              <v-text-field
                v-model="registerInfo.displayName"
                label="昵称"
                outlined
                :rules="displayNameRules"
              ></v-text-field>
              <v-text-field
                v-model="registerInfo.password"
                label="密码"
                type="password"
                outlined
                :rules="passwoordRules"
              ></v-text-field>
              <v-text-field
                v-model="registerInfo.confirmPassword"
                label="确认密码"
                type="password"
                :error-messages="confirmPasswordErrorMessage"
                outlined
                :rules="confirmPasswordRules"
                @blur="checkConfirmPassword"
              ></v-text-field>
              <v-checkbox
                v-model="registerInfo.isAgree"
                :rules="[(v) => !!v || '必须同意才能继续注册']"
              >
                <template v-slot:label>
                  我已阅读并同意
                  <a @click.stop="agreement">《注册协议和隐私政策》</a>
                </template>
              </v-checkbox>
              <v-btn block color="primary" @click="submit">注册</v-btn>
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
    <v-dialog v-model="dialogAgreement" max-width="800">
      <v-card tile>
        <v-card-title>BugChang's Blog 注册协议和隐私政策</v-card-title>
        <v-divider></v-divider>
        <v-card-text class="pt-2 text--primary">
          <ProtocolContent></ProtocolContent>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-snackbar
      v-model="noticeVisible"
      top
      right
      :color="noticeColor"
      timeout="2500"
    >
      {{ noticeMessage }}
      <v-btn text @click="noticeVisible = false">关闭</v-btn>
    </v-snackbar>
  </v-container>
</template>
<script>
import md5 from 'js-md5'
import ProtocolContent from '@/components/ProtocolContent'
export default {
  layout: 'blank',
  components: { ProtocolContent },
  data: () => {
    return {
      valid: false,
      dialogAgreement: false,
      registerInfo: {
        email: '',
        userName: '',
        password: '',
        confirmPassword: '',
        displayName: '',
        isAgree: false,
      },
      confirmPasswordErrorMessage: '',
      emailRules: [
        (v) => !!v || '邮箱字段是必填的',
        (v) => /.+@.+\..+/.test(v) || '邮箱格式不合法',
      ],
      userNameRules: [
        (v) => !!v || '用户名字段是必填的',
        (v) => v.length > 5 || '用户名不能少于5个字符',
        (v) =>
          /^[a-zA-z][0-9a-zA-z]/.test(v) ||
          '用户名只能包含数字和字母,并以字母开头',
      ],
      passwoordRules: [
        (v) => !!v || '密码字段是必填的',
        (v) => v.length >= 8 || '密码长度不能小于8位',
      ],
      confirmPasswordRules: [(v) => !!v || '请再次输入您的密码'],
      displayNameRules: [(v) => !!v || '昵称字段是必填的'],
      noticeVisible: false,
      noticeMessage: '',
      noticeColor: 'secondary',
    }
  },
  methods: {
    // 注册协议
    agreement(e) {
      e.preventDefault()
      this.dialogAgreement = true
    },
    async submit() {
      if (this.validate()) {
        try {
          this.registerInfo.password = md5(this.registerInfo.password)
          this.registerInfo.confirmPassword = md5(
            this.registerInfo.confirmPassword
          )
          await this.$axios.$post('/accounts', this.registerInfo)
          this.showNotice('success', '注册成功，正在跳转至登录页面...')
          const vm = this
          setTimeout(() => {
            vm.$router.push('/login')
          }, 2000)
        } catch (error) {
          if (error.response.status === 400) {
            this.showNotice('error', error.response.data.error)
          }
        }
      }
    },
    checkConfirmPassword() {
      if (
        this.registerInfo.confirmPassword &&
        this.registerInfo.confirmPassword !== this.registerInfo.password
      ) {
        this.confirmPasswordErrorMessage = '两次密码输入不一致'
        this.valid = false
      } else {
        this.valid = true
        this.confirmPasswordErrorMessage = ''
      }
    },
    validate() {
      return this.$refs.form.validate()
    },
    showNotice(type, msg) {
      this.noticeColor = type
      this.noticeMessage = msg
      this.noticeVisible = true
    },
  },

  head() {
    return {
      title: `新用户注册`,
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
