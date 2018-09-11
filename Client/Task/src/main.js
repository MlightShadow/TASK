// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import MuseUI from 'muse-ui'
import 'muse-ui/dist/muse-ui.css'
import 'material-design-icons/iconfont/material-icons.css'
import axios from 'axios'

Vue.config.productionTip = false
Vue.use(MuseUI)
Vue.use(axios)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router: router,
  components: { App },
  template: '<App/>'
})
