<style>
.act {
  border-bottom: pink 2px solid;
}
</style>
<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <!-- <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon> -->
      <v-toolbar-title>BugChang's Blog</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn text to="/" active-class="act">
          <v-icon>mdi-home</v-icon>首 页</v-btn
        >
        <v-menu offset-y active-class="act">
          <template v-slot:activator="{ on }">
            <v-btn text dark v-on="on">
              分类<v-icon>mdi-menu-down</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item to="/1">
              <v-list-item-title>分类1</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <v-btn text to="/tags" active-class="act">标签</v-btn>
        <v-btn text to="/about" active-class="act">关于</v-btn>
        <v-btn text to="/contact" active-class="act">联系</v-btn>
      </v-toolbar-items>
    </v-app-bar>
    <!-- <LeftDrawer :drawer="drawer"></LeftDrawer> -->
    <v-content class="mt-4">
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
// import LeftDrawer from '@/components/LeftDrawer'
export default {
  // components: { LeftDrawer },
  data() {
    return {
      drawer: false,
    }
  },
}
</script>
