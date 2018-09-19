import Vue from 'vue'
import vuex from 'vuex'
import aematerial from './modules/aematerial'

Vue.use(vuex)

export default new vuex.Store({
  modules: {
    aematerial: aematerial
  }
})
