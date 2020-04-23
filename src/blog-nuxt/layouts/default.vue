<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon></v-app-bar-nav-icon>
      <v-toolbar-title>BugChang's Blog</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer class="primary lighten-1" permanent app dark>
      <v-list rounded>
        <v-list-item v-for="item in items" :key="item.title" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <template v-slot:append>
        <div class="pa-2">
          <v-btn block>Logout</v-btn>
        </div>
      </template>
    </v-navigation-drawer>
    <v-content>
      <nuxt />
    </v-content>
    <v-footer app>
      <div class="text-center" style="width: 100%;">
        &copy; CopyRight 2019- {{ new Date().getFullYear() }} BugChang.COM Inc.
        All Rights Reserved. 辽ICP备19020610号-1
      </div>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      items: [
        { title: 'Dashboard', icon: 'mdi-plus' },
        { title: 'Account', icon: 'mdi-account' },
        { title: 'Admin', icon: 'mdi-gavel' },
      ],
    }
  },
}
</script>
