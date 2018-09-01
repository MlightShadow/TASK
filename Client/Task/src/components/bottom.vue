<template>
  <div>
  <mu-bottom-nav style="width:100%; height:60px" :value.sync="shift">
    <router-link to="/"><mu-bottom-nav-item value="home" title="主站" icon="home"></mu-bottom-nav-item></router-link>
    <router-link to="/friends"><mu-bottom-nav-item value="search" title="圈子" icon="face"></mu-bottom-nav-item></router-link>
    <router-link to="/"><mu-bottom-nav-item value="add" title="资料" icon="folder"></mu-bottom-nav-item></router-link>
    <router-link to="/tasklist"><mu-bottom-nav-item value="list" title="任务" icon="list"></mu-bottom-nav-item></router-link>
  </mu-bottom-nav>
  </div>
</template>

<script>
export default {
  name: 'bottom',
  data () {
    return {
      shift: 'home'
    }
  }
}
</script>

<style>
a{
   color: rgba(0,0,0,.54)
}
</style>
