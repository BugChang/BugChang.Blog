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
export default {
  asyncData({ params }) {
    const items = [
      {
        text: '首页',
        disabled: false,
        to: '/',
        exact: true,
      },
      {
        text: '标签',
        disabled: false,
        to: '/tag',
        exact: true,
      },
      {
        text: params.name,
        disabled: true,
        to: '',
        exact: true,
      },
    ]
    const tags = [
      'Work',
      '写作业',
      'Vacation',
      'Food',
      'Drawers',
      'Shopping',
      'Art',
      'Tech',
      'Creative Writing',
    ]
    return { items, tags }
  },
}
</script>
