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
  async asyncData({ params, $axios, query }) {
    let page = query.page
    if (!page) {
      page = 1
    }
    const archiveDate = params.date
    const data = await $axios.$get(
      `/archives/${archiveDate}/posts?page=${page}`
    )
    const archiveDateArray = archiveDate.split('-')
    const archiveDateText = `${archiveDateArray[0]}年${archiveDateArray[1]}月`
    const items = [
      {
        text: '首页',
        disabled: false,
        href: '/',
      },
      {
        text: '归档',
        disabled: true,
        href: '',
      },
      {
        text: archiveDateText,
        disabled: true,
        href: 'breadcrumbs_link_2',
      },
    ]
    return {
      items,
      archiveDate,
      archiveDateText,
      posts: data.records,
      page: data.page,
      pageCount: data.pageCount,
    }
  },
  data: () => {
    return {}
  },
  computed: {},
  methods: {
    jump(page) {
      if (page === 1) {
        this.$router.push('')
      } else {
        this.$router.push(`${this.archiveDate}/p${page}`)
      }
    },
  },
  head() {
    return {
      title: `归档 | ${this.archiveDateText}`,
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
