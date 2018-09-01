import Vue from 'vue'
import Router from 'vue-router'
import home from '@/pages/home'
import tasklist from '@/pages/tasklist'
import friends from '@/pages/friends'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: home
    },
    {
      path: '/tasklist',
      name: 'tasklist',
      component: tasklist
    },
    {
      path: '/friends',
      name: 'friends',
      component: friends
    }
  ]
})
