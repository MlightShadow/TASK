// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import MuseUI from 'muse-ui'
import 'muse-ui/dist/muse-ui.css'
import 'material-design-icons/iconfont/material-icons.css'
import axios from './plugin/axios'
import store from './store'

Vue.config.productionTip = false
Vue.prototype.$axios = axios
Vue.use(MuseUI)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router: router,
  store: store,
  components: { App },
  template: '<App/>'
})
