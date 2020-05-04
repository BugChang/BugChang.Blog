<template>
  <v-container fluid>
    <v-data-table :headers="headers" :items="categories" class="elevation-1">
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>分类</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on }">
              <v-btn color="primary" dark class="mb-2" v-on="on"
                >新增分类</v-btn
              >
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        v-model="editedCategory.name"
                        label="名称"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-select
                        v-model="editedCategory.color"
                        :items="colors"
                        label="颜色"
                      >
                        <template v-slot:item="{ item }">
                          <v-avatar :color="item" size="32" class="mx-2" left>
                          </v-avatar>
                          <span>{{ item }}</span>
                        </template>
                      </v-select>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn text @click="close">取消</v-btn>
                <v-btn color="primary" text @click="save">保存</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editCategory(item.id)"
          >mdi-pencil</v-icon
        >
        <v-icon small @click="deleteCategory(item.id)">mdi-delete</v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="getCategories">
          <v-icon>mdi-refresh</v-icon>
          刷新一下</v-btn
        >
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
export default {
  layout: 'admin',
  data: () => ({
    dialog: false,
    headers: [
      { text: '主键', value: 'id' },
      { text: '名称', value: 'name' },
      { text: '颜色', value: 'color' },
      { text: '文章数量', value: 'postCount' },
      { text: '操作', value: 'actions' },
    ],
    categories: [],
    colors: [],
    editedCategory: {
      id: 0,
      name: '',
      color: '',
    },
    defaultCategory: {
      id: 0,
      name: '',
      color: '',
    },
  }),

  computed: {
    formTitle() {
      return this.editedCategory.id === 0 ? '新增分类' : '修改分类'
    },
  },

  watch: {
    dialog(val) {
      val || this.close()
    },
  },

  created() {
    this.getCategories()
    this.getColors()
  },

  methods: {
    async editCategory(categoryId) {
      const category = await this.getCategory(categoryId)
      this.editedCategory = Object.assign({}, category)
      this.dialog = true
    },

    async deleteCategory(categoryId) {
      if (confirm('Are you sure you want to delete this item?')) {
        await this.$axios.$delete('/categories/' + categoryId)
        await this.getCategories()
      }
    },

    close() {
      this.dialog = false
      setTimeout(() => {
        this.editedCategory = Object.assign({}, this.defaultCategory)
      }, 300)
    },

    async save() {
      if (this.editedCategory.id > 0) {
        await this.$axios.$put(
          '/categories/' + this.editedCategory.id,
          this.editedCategory
        )
      } else {
        await this.$axios.$post('/categories', this.editedCategory)
      }
      this.getCategories()
      this.close()
    },
    async getCategories() {
      const data = await this.$axios.$get('/categories')
      this.categories = data
    },
    async getColors() {
      const data = await this.$axios.$get('/categories/colors')
      this.colors = data
    },

    async getCategory(categoryId) {
      const category = await this.$axios.$get('/categories/' + categoryId)
      return category
    },
  },
}
</script>
