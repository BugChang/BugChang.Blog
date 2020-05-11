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
  asyncData() {
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
