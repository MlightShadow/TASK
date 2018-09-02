<template>
  <div>
  <mu-form :model="item" :label-position="'right'" label-width="100">
    <mu-form-item prop="input" label="姓名">
      <mu-text-field v-model="form.name"></mu-text-field>
    </mu-form-item>
    <mu-form-item prop="date" label="生日">
      <mu-date-input v-model="form.brithday" type="date" actions></mu-date-input>
    </mu-form-item>
    <mu-form-item prop="radio" label="性别">
      <mu-radio v-model="form.gender" value="male" label="男"></mu-radio>
      <mu-radio v-model="form.gender" value="female" label="女"></mu-radio>
    </mu-form-item>
    <mu-form-item prop="textarea" label="备注">
      <mu-text-field multi-line :rows="3" :rows-max="6" v-model="form.remarks"></mu-text-field>
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
      options: [
        'Option 1', 'Option 2', 'Option 3', 'Option 4',
        'Option 5', 'Option 6', 'Option 7', 'Option 8',
        'Option 9', 'Option 10'
      ],
      item: {
        name: '',
        select: '',
        date: '',
        radio: '',
        checkbox: [],
        switch: false,
        slider: 30,
        textarea: ''
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
