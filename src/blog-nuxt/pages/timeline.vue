<template>
  <v-container fluid>
    <v-card>
      <v-img src="https://api.ixiaowai.cn/api/api.php" max-height="320"></v-img>
      <v-card-title class="headline">时间轴</v-card-title>
      <v-divider></v-divider>
      <v-card-text class="text--primary body-1">
        <v-timeline align-top dense>
          <v-timeline-item color="pink" small>
            <v-row class="pt-1">
              <v-col cols="3">
                <strong>2020.6.1</strong>
              </v-col>
              <v-col>
                <strong>功能上线、优化</strong>
                <ul>
                  <li>评论功能优化</li>
                  <li>注册登录功能上线</li>
                  <li>AppBar样式改版</li>
                </ul>
              </v-col>
            </v-row>
          </v-timeline-item>
          <v-timeline-item color="pink" small>
            <v-row class="pt-1">
              <v-col cols="3">
                <strong>2020.5.25</strong>
              </v-col>
              <v-col>
                <strong>新功能上线</strong>
                <ul>
                  <li>评论功能上线</li>
                  <li>分享功能上线</li>
                </ul>
              </v-col>
            </v-row>
          </v-timeline-item>
          <v-timeline-item color="pink" small>
            <v-row class="pt-1">
              <v-col cols="3">
                <strong>2020.5.13</strong>
              </v-col>
              <v-col>
                <strong>网站上线</strong>
                <div>
                  BugChang's Blog 正式上线，想想还有些兴奋呢
                </div>
              </v-col>
            </v-row>
          </v-timeline-item>
        </v-timeline>
      </v-card-text>
    </v-card>
  </v-container>
</template>
