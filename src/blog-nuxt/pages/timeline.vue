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
