<template>
  <div id="app">

    <top />
    <router-view/>

    <bottom />
  </div>
</template>

<script>
import bottom from './components/bottom.vue'
import top from './components/top.vue'
export default {
  name: 'App',
  components: {
    bottom,
    top
  }
}
</script>

<style scoped>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-bottom: 50px;
  margin-top: 40px;
}
</style>
