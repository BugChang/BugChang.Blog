<style>
.v-list-item__avatar {
  align-self: center;
  justify-content: center;
}
</style>
<template>
  <v-navigation-drawer v-model="drawer" width="300" app clipped>
    <BusinessCard></BusinessCard>
    <v-divider></v-divider>
    <v-list>
      <v-list-item to="/">
        <v-list-item-icon>
          <v-icon>mdi-home</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>首页</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-group no-action prepend-icon="mdi-book-open">
        <template v-slot:activator>
          <v-list-item-content>
            <v-list-item-title>分类</v-list-item-title>
          </v-list-item-content>
        </template>
        <v-list-item
          v-for="category in categories"
          :key="category.name"
          :to="'/category/' + category.id"
        >
          <v-list-item-title v-text="category.name" />
          <v-list-item-avatar tile size="24" right color="primary lighten-1">
            <span class="white--text">
              {{ category.postCount }}
            </span>
          </v-list-item-avatar>
        </v-list-item>
      </v-list-group>
      <v-list-group no-action prepend-icon="mdi-archive">
        <template v-slot:activator>
          <v-list-item-content>
            <v-list-item-title>归档</v-list-item-title>
          </v-list-item-content>
        </template>
        <v-list-item
          v-for="(archive, i) in archives"
          :key="i"
          :to="'/archive/' + archive.year + '-' + archive.month"
        >
          <v-list-item-title
            >{{ archive.year }}年{{ archive.month }}月</v-list-item-title
          >
          <v-list-item-avatar tile size="24" right>
            <span class="white--text">{{ archive.count }}</span>
          </v-list-item-avatar>
        </v-list-item>
      </v-list-group>
      <v-list-item to="/tags">
        <v-list-item-icon>
          <v-icon>mdi-tag-multiple</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>标签</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-item to="/timeline">
        <v-list-item-icon>
          <v-icon>mdi-update</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>时间轴</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-item to="/about">
        <v-list-item-icon>
          <v-icon>mdi-information</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>关于</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>
<script>
import BusinessCard from '@/components/BusinessCard'
export default {
  components: { BusinessCard },
  props: {
    drawer: Boolean,
  },

  data: () => {
    return {}
  },
  computed: {
    categories() {
      return this.$store.state.navCategories
    },
    archives() {
      return this.$store.state.navArchives
    },
  },
  created() {},
  methods: {},
}
</script>
