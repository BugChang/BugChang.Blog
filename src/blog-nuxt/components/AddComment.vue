<template>
  <v-card>
    <v-card-title>
      添加评论
    </v-card-title>
    <v-card-text class="pb-0">
      <v-form>
        <v-row dense>
          <v-col cols="12" md="6">
            <v-text-field label="姓名" filled></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <v-text-field label="邮箱" filled></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-textarea filled auto-grow rows="3" label="内容"></v-textarea>
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn class="primary">提交</v-btn>
    </v-card-actions>
  </v-card>
</template>
