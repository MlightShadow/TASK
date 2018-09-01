<template>
    <div>
        <mu-dialog  transition="slide-bottom" fullscreen :open.sync="isShow">
            <mu-appbar style="width:100%" color="primary" :title="showItem.title">
                <mu-button slot="left" icon @click="closeFullscreenDialog">
                    <mu-icon value="close"></mu-icon>
                </mu-button>
            </mu-appbar>
            <div>
                {{ showItem.description }}
            </div>
        </mu-dialog>
    </div>
</template>

<script scoped>
export default {
  name: 'detail_dialog',
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
