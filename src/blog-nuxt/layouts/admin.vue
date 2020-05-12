<template>
  <v-app>
    <v-app-bar app color="primary" height="70" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn text to="/">返回前台</v-btn>
        <v-btn text @click="logout">注销</v-btn>
      </v-toolbar-items>
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      app
      width="300"
      :mini-variant="miniDrawer"
      mini-variant-width="70"
    >
      <v-toolbar color="primary darken-1" dark height="70">
        <v-toolbar-title v-if="!miniDrawer"
          >BugChang's Blog Admin</v-toolbar-title
        >
        <v-toolbar-title v-else>BBA</v-toolbar-title>
      </v-toolbar>
      <v-list>
        <template v-for="item in menus">
          <v-list-group v-if="item.children" :key="item.title" no-action>
            <template v-slot:activator>
              <v-list-item-icon>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </template>
            <v-list-item
              v-for="subItem in item.children"
              :key="subItem.title"
              :to="subItem.to"
              exact
            >
              <v-list-item-icon>
                <v-icon>{{ subItem.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>{{ subItem.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-group>
          <v-list-item v-else :key="item.title" :to="item.to" exact>
            <v-list-item-icon>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-content>
      <nuxt></nuxt>
    </v-content>
  </v-app>
</template>

<script>
const Cookie = process.client ? require('js-cookie') : undefined
export default {
  middleware: 'authentication',
  data: () => ({
    drawer: true,
    miniDrawer: false,
    menus: [
      {
        title: '仪表盘',
        to: '/admin',
        icon: 'mdi-home',
      },
      {
        title: '分类管理',
        to: '/admin/category',
        icon: 'mdi-folder',
      },
      {
        title: '文章管理',
        icon: 'mdi-post',
        children: [
          {
            title: '写文章',
            to: '/admin/post/write',
            icon: 'mdi-fountain-pen-tip',
          },
          {
            title: '所有文章',
            to: '/admin/post',
            icon: 'mdi-book-open-page-variant',
          },
        ],
      },
      {
        title: '标签',
        to: '/admin/tags',
        icon: 'mdi-tag',
      },
      {
        title: '关于',
        to: '/admin/about',
        icon: 'mdi-information',
      },
    ],
  }),
  methods: {
    logout() {
      Cookie.remove('token')
      this.$store.commit('setToken', null)
      this.$router.push('/')
    },
  },
}
</script>
