<template>
  <v-container>
    <v-breadcrumbs class="pl-0" :items="items"></v-breadcrumbs>
    <v-row justify="space-around">
      <v-col cols="12">
        <v-sheet tile class="pa-4">
          <v-chip-group column active-class="primary--text">
            <v-chip v-for="tag in tags" :key="tag" :to="`/tag/${tag}`">
              {{ tag }}
            </v-chip>
          </v-chip-group>
        </v-sheet>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  async asyncData({ $axios }) {
    const items = [
      {
        text: '首页',
        disabled: false,
        href: '/',
      },
      {
        text: '标签',
        disabled: true,
        href: '',
      },
    ]
    const tags = await $axios.$get('/tags')
    return { items, tags }
  },
  head() {
    return {
      title: '标签',
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
