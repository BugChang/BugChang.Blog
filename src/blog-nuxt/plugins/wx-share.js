import Vue from 'vue'
import wx from 'weixin-js-sdk'
Vue.prototype.$wechat = wx

const wechatShare = {
  install(Vue) {
    Vue.prototype.wxShare = function (shareData, url) {
      this.$axios.$get('/wechat/shareconfig?url=' + url).then((data) => {
        this.$wechat.config({
          debug: false,
          appId: data.appId,
          timestamp: data.timestamp,
          nonceStr: data.nonceStr,
          signature: data.signature,
          jsApiList: data.jsApiList,
        })
      })

      this.$wechat.ready(() => {
        // 自定义“分享给朋友”及“分享到QQ”按钮的分享内容（1.4.0）
        this.$wechat.updateAppMessageShareData({
          title: shareData.title,
          desc: shareData.desc,
          link: shareData.url,
          imgUrl: shareData.image,
          success() {
            // 设置成功
          },
          cancel() {},
        })
        // 自定义“分享到朋友圈”及“分享到QQ空间”按钮的分享内容（1.4.0）
        this.$wechat.updateTimelineShareData({
          title: shareData.title,
          desc: shareData.desc,
          link: shareData.url,
          imgUrl: shareData.image,
          success() {
            // 设置成功
          },
          cancel() {},
        })
      })
      this.$wechat.error((res) => {})
    }
  },
}

Vue.use(wechatShare)
