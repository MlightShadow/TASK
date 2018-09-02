<template>
  <div>
      <mu-flex justify-content="center">
        <mu-button style="width:95%; margin-top:6px;margin-bottom:6px;" color="green">添加资料</mu-button>
      </mu-flex>
        <mu-expansion-panel>
            <div slot="header">王二麻子</div>
            王二麻子王二麻子王二麻子王二麻子王二麻子王二麻子王二麻子
            <mu-button slot="action" flat color="primary">详情</mu-button>
        </mu-expansion-panel>
        <mu-expansion-panel>
            <div slot="header">Panel 2</div>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse malesuada lacus ex, sit amet blandit leo lobortis eget.
            <mu-button slot="action" flat color="primary">详情</mu-button>
        </mu-expansion-panel>
        <mu-expansion-panel>
            <div slot="header">Panel 3</div>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse malesuada lacus ex, sit amet blandit leo lobortis eget.
            <mu-button slot="action" flat color="primary">详情</mu-button>
        </mu-expansion-panel>
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

</style>
