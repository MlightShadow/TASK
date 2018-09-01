<template>
  <div>
      <mu-paper :z-depth="1" class="demo-list-wrap">
        <mu-list textline="two-line">
            <div v-for="item in items">
                <mu-divider></mu-divider>
                <mu-list-item  avatar :ripple="false" button @click="showDetail(item)">
                <mu-list-item-content>
                    <mu-list-item-title>{{ item.title }}</mu-list-item-title>
                    <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">
                    {{ item.description }}
                    </mu-list-item-sub-title>
                    <mu-list-item-sub-title >任务类型: {{ item.type }}</mu-list-item-sub-title>

                </mu-list-item-content>
                <mu-list-item-action >
                    <mu-list-item-after-text>
                        {{ item.time }}
                        </mu-list-item-after-text>
                    <mu-list-item-after-text>
                        负责人: {{ item.master }}
                        </mu-list-item-after-text>
                </mu-list-item-action>
                </mu-list-item>
            </div>
        </mu-list>
    </mu-paper>

    <detaildialog :isShow.sync="isShow" :showItem.sync="showItem"/>
  </div>
</template>

<script>
import detaildialog from './../components/detail_dialog.vue'
export default {
  name: 'tasklist',
  data () {
    return {
      items: [
        {
          title: '任务一',
          description: '这是个简单的任务',
          type: '开发',
          time: '2018-9-1 21:31',
          master: '张三'
        },
        {
          title: '复杂的任务',
          description: '简述简述简述简述简述简述简述简述简述简述简述简述简述简述简述简述简述简述简述',
          type: '调研',
          time: '2018-9-1 21:31',
          master: '王二麻子'
        }
      ],
      isShow: false,
      showItem: {}
    }
  },
  components: {
    detaildialog
  },
  methods: {
    showDetail: function (item) {
      this.showItem = item
      this.isShow = true
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

.mu-item-action {
  min-width: 100px;
}
</style>
