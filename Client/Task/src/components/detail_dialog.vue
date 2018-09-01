<template>
    <div>
        <mu-dialog  transition="slide-bottom" fullscreen :open.sync="openFullscreen">
            <mu-appbar style="width:100%" color="primary" title="Fullscreen Diaolog">
                <mu-button slot="left" icon @click="closeFullscreenDialog">
                    <mu-icon value="close"></mu-icon>
                </mu-button>
            </mu-appbar>
            <div>
                this is a fullscreen dialog
            </div>
        </mu-dialog>
    </div>
</template>

<script>
export default {
  name: 'detail_dialog',
  props: {
    openFullscreen: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    closeFullscreenDialog () {
      this.$emit('update:openFullscreen', false)
    }
  }
}
</script>
