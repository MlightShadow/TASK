<template>
  <div>
  <mu-form :model="item" :label-position="'right'" label-width="100">
    {{$store.state.aematerial.show}}
    <mu-form-item prop="input" label="姓名">
      <mu-text-field v-model="item.name"></mu-text-field>
    </mu-form-item>
    <mu-form-item prop="date" label="生日">
      <mu-date-input v-model="item.brithday" type="date" actions></mu-date-input>
    </mu-form-item>
    <mu-form-item prop="radio" label="性别">
      <mu-radio v-model="item.gender" value="male" label="男"></mu-radio>
      <mu-radio v-model="item.gender" value="female" label="女"></mu-radio>
    </mu-form-item>
    <mu-form-item prop="textarea" label="备注">
      <mu-text-field multi-line :rows="3" :rows-max="6" v-model="item.remarks"></mu-text-field>
    </mu-form-item>
    <mu-form-item label="尺寸附件">
      <fileupload />
    </mu-form-item>
  </mu-form>
  </div>
</template>

<script>
import fileupload from './../components/fileupload.vue'
export default {
  name: 'aematerial',
  data () {
    return {
      item: {
        name: '',
        brithday: '',
        gender: '',
        radio: '',
        remarks: ''
      }
    }
  },
  components: {
    fileupload
  }
}
</script>

<style scoped>
</style>
