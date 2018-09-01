<template>
  <div>
      <mu-paper :z-depth="1" class="demo-list-wrap">
        <mu-list textline="two-line" >
            <mu-list-item avatar :ripple="false" button @click="openFullscreenDialog">
            <mu-list-item-content>
                <mu-list-item-title>Ali Connors</mu-list-item-title>
                <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">Brunch this weekend?</mu-list-item-sub-title>
                <mu-list-item-sub-title>
                I'll be in your neighborhood doing errands this weekend. Do you want to hang out?
                </mu-list-item-sub-title>
            </mu-list-item-content>
            <mu-list-item-action >
                <mu-list-item-after-text>15 min</mu-list-item-after-text> 
                <mu-list-item-after-text>赵一二三</mu-list-item-after-text> 
            </mu-list-item-action>
            </mu-list-item>
            <mu-divider></mu-divider>
            <mu-list-item avatar :ripple="false" button>
            <mu-list-item-content>
                <mu-list-item-title>me, Scrott, Jennifer</mu-list-item-title>
                <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">Summer BBQ</mu-list-item-sub-title>
                <mu-list-item-sub-title>
                Wish I could come, but I'm out of town this weekend.
                </mu-list-item-sub-title>
            </mu-list-item-content>
            <mu-list-item-action >
                <mu-list-item-after-text>2 hr</mu-list-item-after-text>
                <mu-checkbox color="yellow700" v-model="selects" value="value2"  uncheck-icon="star_border" checked-icon="star"></mu-checkbox>
            </mu-list-item-action>
            </mu-list-item>
            <mu-divider></mu-divider>
            <mu-list-item avatar :ripple="false" button>
            <mu-list-item-content>
                <mu-list-item-title>Sandra Adams</mu-list-item-title>
                <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">Oui oui</mu-list-item-sub-title>
                <mu-list-item-sub-title>
                Do you have Paris recommendations? Have you ever been?
                </mu-list-item-sub-title>
            </mu-list-item-content>
            <mu-list-item-action >
                <mu-list-item-after-text>6 hr</mu-list-item-after-text>
                <mu-checkbox color="yellow700" v-model="selects" value="value3"  uncheck-icon="star_border" checked-icon="star"></mu-checkbox>
            </mu-list-item-action>
            </mu-list-item>
            <mu-divider></mu-divider>
            <mu-list-item avatar :ripple="false" button>
            <mu-list-item-content>
                <mu-list-item-title>Trevor Hansen</mu-list-item-title>
                <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">Birthday gift</mu-list-item-sub-title>
                <mu-list-item-sub-title>
                Have any ideas about what we should get Heidi for her
                </mu-list-item-sub-title>
            </mu-list-item-content>
            <mu-list-item-action>
                <mu-list-item-after-text>12 hr</mu-list-item-after-text>
                <mu-checkbox color="yellow700" v-model="selects" value="value4"  uncheck-icon="star_border" checked-icon="star"></mu-checkbox>
            </mu-list-item-action>
            </mu-list-item>
            <mu-divider></mu-divider>
            <mu-list-item avatar :ripple="false" button>
            <mu-list-item-content>
                <mu-list-item-title>Britta Holt</mu-list-item-title>
                <mu-list-item-sub-title style="color: rgba(0, 0, 0, .87)">Recipe to try</mu-list-item-sub-title>
                <mu-list-item-sub-title>
                We should eat this: Grate, Squash, Corn, and tomatillo Tacos.
                </mu-list-item-sub-title>
            </mu-list-item-content>
            <mu-list-item-action >
                <mu-list-item-after-text>18hr</mu-list-item-after-text>
                <mu-checkbox color="yellow700" v-model="selects" value="value5"  uncheck-icon="star_border" checked-icon="star"></mu-checkbox>
            </mu-list-item-action>
            </mu-list-item>
        </mu-list>
    </mu-paper>

    <detaildialog :openFullscreen.sync="openFullscreen"/>
  </div>
</template>

<script>
import detaildialog from './../components/detail_dialog.vue'
export default {
  name: 'tasklist',
  data () {
    return {
      selects: [],
      openFullscreen: false
    }
  },
  components: {
    detaildialog
  },
  methods: {
    openFullscreenDialog: function () {
      this.openFullscreen = true
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.demo-list-wrap {
  width: 100%;
  overflow: hidden;
}
</style>
