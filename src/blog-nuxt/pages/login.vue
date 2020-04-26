<style scoped>
.login-card {
  margin: 0 auto;
}
</style>
<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" md="8" lg="4">
        <v-form>
          <v-card max-width="400" class="mx-auto" elevation="8">
            <v-toolbar color="primary" dark>
              <v-toolbar-title>登录</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-text-field label="用户名"></v-text-field>
              <v-text-field label="密码" type="password"></v-text-field>
              <v-checkbox label="7天内免登录"></v-checkbox>
            </v-card-text>
            <v-card-actions>
              <v-btn color="primary" tile block>登录</v-btn>
            </v-card-actions>
          </v-card>
        </v-form>
      </v-col>
    </v-row>
  </v-container>
</template>
