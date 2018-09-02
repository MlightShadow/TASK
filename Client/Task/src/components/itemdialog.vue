<template>
    <div>
        <mu-dialog transition="slide-bottom" fullscreen :open.sync="isShow" style="margin-top: 40px;">
            <mu-appbar style="width:100%; height: 40px;" color="primary" :title="showItem.title">
                <mu-button slot="left" icon @click="closeFullscreenDialog">
                    <mu-icon value="close"></mu-icon>
                </mu-button>
            </mu-appbar>
            <div :style="'padding: 6px; overflow: auto; width:'+width+'; height:'+height+';'">
                {{ showItem.description }}
                <aematerial />
            </div>
        </mu-dialog>
    </div>
</template>

<script>
import aematerial from './../components/aematerial.vue'
import aetask from './../components/aetask.vue'
export default {
  name: 'itemdialog',
  components: {
    aematerial,
    aetask
  },
  data () {
    return {
      width: (window.innerWidth) + 'px',
      height: (window.innerHeight) + 'px'
    }
  },
  props: {
    isShow: {
      type: Boolean,
      default: false
    },
    showItem: {}
  },
  methods: {
    closeFullscreenDialog () {
      this.$emit('update:isShow', false)
    }
  }
}
</script>

<style scoped>
.mu-appbar{
  position:fixed;
  top:0px;
}
</style>
