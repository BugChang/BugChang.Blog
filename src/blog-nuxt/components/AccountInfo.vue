<template>
  <v-menu
    v-if="!!currentUser"
    v-model="menu"
    :close-on-content-click="false"
    offset-y
  >
    <template v-slot:activator="{ on }">
      <v-btn text v-on="on">
        {{ currentUser.nickName }}
        <v-icon right>
          mdi-menu-down
        </v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-list>
        <v-list-item>
          <v-list-item-avatar>
            <img src="/image/logo160x160.png" :alt="currentUser.nickName" />
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title>{{ currentUser.nickName }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <v-divider></v-divider>
      <v-list>
        <v-list-item to="/profile">
          <v-list-item-title>
            <v-icon left>mdi-account</v-icon>
            个人资料</v-list-item-title
          >
        </v-list-item>
        <v-list-item v-if="showAdmin" to="/admin">
          <v-list-item-title>
            <v-icon left>mdi-cog</v-icon>
            后台管理</v-list-item-title
          >
        </v-list-item>
        <v-list-item @click="logout">
          <v-list-item-title>
            <v-icon left>mdi-logout</v-icon>
            安全退出</v-list-item-title
          >
        </v-list-item>
      </v-list>
    </v-card>
  </v-menu>
  <v-menu v-else offset-y>
    <template v-slot:activator="{ on }">
      <v-btn dark icon v-on="on">
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </template>
    <v-list>
      <v-list-item to="/login">
        <v-icon left>mdi-login</v-icon>
        <v-list-item-title>登 录</v-list-item-title>
      </v-list-item>
      <v-list-item to="/register">
        <v-icon left>mdi-account-plus</v-icon>
        <v-list-item-title>注 册</v-list-item-title>
      </v-list-item>
    </v-list>
  </v-menu>
</template>
<script>
const Cookie = process.client ? require('js-cookie') : undefined
export default {
  data() {
    return {
      menu: false,
      message: true,
      hints: true,
      accountInfo: {},
    }
  },
  computed: {
    showAdmin() {
      return this.currentUser.role === 'Admin'
    },
    currentUser() {
      return this.$store.state.currentUser
    },
  },
  methods: {
    logout() {
      Cookie.remove('token')
      this.$store.commit('setToken', null)
      Cookie.remove('currentUser')
      this.$store.commit('setUserInfo', null)
    },
  },
}
</script>
