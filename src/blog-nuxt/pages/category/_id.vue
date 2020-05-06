<template>
  <v-container>
    <v-breadcrumbs class="pl-0" :items="items"></v-breadcrumbs>
    <PostPreview
      v-for="post in posts"
      :key="post.id"
      :post="post"
      class="mb-4 align-self-center"
      style="width: 100%;"
    />
    <div class="text-center">
      <v-pagination
        v-model="page"
        :length="pageCount"
        @input="jump"
      ></v-pagination>
    </div>
  </v-container>
</template>

<script>
import PostPreview from '@/components/PostPreview'
export default {
  components: { PostPreview },
  async asyncData({ $axios, params }) {
    const data = await $axios.$get(`/categories/${params.id}/posts`)
    const categoryName = data.records[0].categoryName
    const items = [
      {
        text: '首页',
        disabled: false,
        href: '/',
      },
      {
        text: '分类',
        disabled: true,
        href: '',
      },
      {
        text: categoryName,
        disabled: true,
        href: 'breadcrumbs_link_2',
      },
    ]
    return {
      categoryName,
      posts: data.records,
      page: data.page,
      pageCount: data.pageCount,
      items,
    }
  },
  data: () => ({}),
  methods: {
    jump(page) {
      if (page === 1) {
        this.$router.push('')
      } else {
        this.$router.push(`?page=${page}`)
      }
    },
  },
  head() {
    return {
      title: `分类 | ${this.categoryName}`,
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
