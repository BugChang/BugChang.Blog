<template>
  <v-card class="my-auto" flat>
    <v-card-text class="font-weight-bold">
      <v-row>
        <v-col class="text-center">
          <v-avatar size="64" class="mb-4">
            <img src="/image/logo160x160.png" alt="BugChang" />
          </v-avatar>
          <p>姓名：常吉 | 网名：BugChang</p>
          <p>职业：.Net高级开发工程师</p>
          <p>现居：辽宁省-沈阳市</p>
          <p>Email：81069681@qq.com</p>
        </v-col>
      </v-row>
      <v-row justify="space-around">
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn
              icon
              href="tencent://message/?uin=81069681&Site=&Menu=yes"
              v-on="on"
            >
              <v-icon>
                mdi-qqchat
              </v-icon>
            </v-btn>
          </template>
          <span>QQ</span>
        </v-tooltip>
        <v-menu :close-on-content-click="false" offset-y>
          <template v-slot:activator="{ on }">
            <v-btn icon v-on="on">
              <v-icon>
                mdi-wechat
              </v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-card-text class="pa-0">
              <v-img src="/image/wechat.jpg" max-width="140px" />
            </v-card-text>
          </v-card>
        </v-menu>

        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn icon href="mailto:cn.changji@qq.com" v-on="on">
              <v-icon>
                mdi-email
              </v-icon>
            </v-btn>
          </template>
          <span>邮箱</span>
        </v-tooltip>

        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn
              icon
              href="https://github.com/BugChang"
              target="_blank"
              v-on="on"
            >
              <v-icon>
                mdi-github
              </v-icon>
            </v-btn>
          </template>
          <span>github</span>
        </v-tooltip>
      </v-row>
    </v-card-text>
  </v-card>
</template>
