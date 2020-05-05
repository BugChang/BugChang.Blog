<template>
  <v-navigation-drawer v-model="drawer" app>
    <v-list rounded>
      <v-list-item v-for="item in items" :key="item.title" :to="item.to">
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>
<script>
export default {
  props: {
    drawer: Boolean,
  },
  data() {
    return {
      items: [
        {
          title: '首页',
          to: '/',
          icon: 'mdi-home',
        },
        {
          title: '分类',
          to: '/category',
          icon: 'mdi-shape',
        },
        {
          title: '标签',
          to: '/tags',
          icon: 'mdi-tag',
        },
        {
          title: '关于',
          to: '/about',
          icon: 'mdi-information',
        },
      ],
    }
  },
}
</script>
