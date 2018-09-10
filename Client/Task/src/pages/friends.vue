<template>
  <div>
<mu-paper :z-depth="1" class="demo-list-wrap">
  <mu-list textline="three-line">
    <mu-list-item avatar :ripple="true" button>
      <mu-list-item-action>
        <mu-avatar>
          <img src="./../assets/priest.jpg">
        </mu-avatar>
      </mu-list-item-action>
      <mu-list-item-content>
        <mu-list-item-title>这个周末一起吃饭么?</mu-list-item-title>
        <mu-list-item-sub-title>
          <span style="color: rgba(0, 0, 0, .87)">Myron Liu -</span> 周末要来你这里出差，要不要一起吃个饭呀，实在编不下去了,哈哈哈哈哈哈
        </mu-list-item-sub-title>
      </mu-list-item-content>
    </mu-list-item>
    <mu-divider></mu-divider>
    <mu-list-item :ripple="false" button>
      <mu-list-item-action>
        <mu-avatar>
          <img src="./../assets/mage.jpg">
        </mu-avatar>
      </mu-list-item-action>
      <mu-list-item-content>
        <mu-list-item-title>Alex Qin</mu-list-item-title>
        <mu-list-item-sub-title>
          <span style="color: rgba(0, 0, 0, .87)">看电影啊</span><br/>
          我们去看电影，最近有部烂片上映，又有吐槽的了
        </mu-list-item-sub-title>
      </mu-list-item-content>
    </mu-list-item>
    <mu-divider></mu-divider>
    <mu-list-item avatar :ripple="false" button>
      <mu-list-item-action>
        <mu-avatar>
          <img src="./../assets/hs.jpg">
        </mu-avatar>
      </mu-list-item-action>
      <mu-list-item-content>
        <mu-list-item-title>LOL</mu-list-item-title>
        <mu-list-item-sub-title>
          <span style="color: rgba(0, 0, 0, .87)">去打游戏啊</span><br/>
          周末一起 LOL
        </mu-list-item-sub-title>
      </mu-list-item-content>
    </mu-list-item>
  </mu-list>
</mu-paper>
  </div>
</template>

<script>
export default {
  name: 'Home',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.demo-list-wrap {
  width: 100%;
  overflow: hidden;
}
</style>
