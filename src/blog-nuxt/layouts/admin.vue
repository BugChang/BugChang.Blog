<template>
  <v-app>
    <v-app-bar app color="primary" height="70" dark>
      <v-app-bar-nav-icon
        @click.stop="miniDrawer = !miniDrawer"
      ></v-app-bar-nav-icon>
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
        <v-tooltip
          v-for="item in menus"
          :key="item.title"
          right
          :disabled="!miniDrawer"
        >
          <template v-slot:activator="{ on }">
            <v-list-item :to="item.to" v-on="on">
              <v-list-item-icon>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </template>
          <span>{{ item.title }}</span>
        </v-tooltip>
      </v-list>
    </v-navigation-drawer>
    <v-content>
      <nuxt></nuxt>
    </v-content>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    drawer: true,
    miniDrawer: false,
    menus: [
      {
        title: '仪表盘',
        to: '/admin/dashboard',
        icon: 'mdi-home',
      },
      {
        title: '分类',
        to: '/admin/category',
        icon: 'mdi-shape',
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
}
</script>
