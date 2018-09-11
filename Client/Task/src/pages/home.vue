<template>
  <div>
  <mu-card style="width: 100%; margin: 0 auto;">
    <mu-card-media title="公告" sub-title="公告简述" style="max-height:200px; overflow: hidden">
      <img src="./../assets/notice.jpg" >
    </mu-card-media>
  </mu-card>

  <div style="width: 100%; background: #fff; padding: 8px;">
    <mu-flex justify-content="center">
      <mu-flex justify-content="center" fill>
        <mu-button color="orange">添加任务</mu-button>
      </mu-flex>

      <mu-flex justify-content="center" fill>
        <mu-button color="success">添加资料</mu-button>
      </mu-flex>
    </mu-flex>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {}
  },
  methods: {
    fetchItem: function () {
      this.$axios.get('api/values/1',{}, response => {
        console.log(JSON.stringify(response))

        // if (response.status >= 200 && response.status < 300) {
        // } else {
        // }
      })
    }
  },
  created: function () {
    this.fetchItem()
  }
}
</script>

<style scoped>
  .mu-button{
    font-size: 20pt;
    height: 100px;
    text-align: center;
    margin: 8px;
    vertical-align: middle;
  }
</style>
