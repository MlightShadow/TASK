<template>
    <div>
        <mu-appbar style="width: 100%;height:40px" color="#2196f3">
            <mu-button icon slot="left" @click="open = !open">
                <mu-icon value="menu"></mu-icon>
            </mu-button>
            SSTask任务列表

            <mu-button flat slot="right">设置</mu-button>
        </mu-appbar>
        <mu-drawer :open.sync="open" :docked="false">
            <mu-list>
                <mu-list-item button>
                    <mu-avatar :size="36">
                        <img src="./../assets/logo.png">
                    </mu-avatar>&nbsp; 未登录
                </mu-list-item>
            <mu-list-item button>
                <mu-list-item-title>操作1</mu-list-item-title>
            </mu-list-item>
            <mu-list-item button>
                <mu-list-item-title>操作2</mu-list-item-title>
            </mu-list-item>
            </mu-list>
        </mu-drawer>
    </div>
</template>

<script>
export default {
  data () {
    return {
      open: false
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
