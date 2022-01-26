<template>
  <aside>
    <div class="main_icon">
      <router-link
        to="/"
      >
        <img class="main_icon__img" src="@/assets/logo.png" alt="메인 아이콘"/>
      </router-link>
    </div>
    <y-menu-list :items="menuList"/>
  </aside>
</template>
<script>
import YMenuList from '@/components/layout/YMenuList'
export default {
  name: 'y-left-aside',
  components: {
    YMenuList,
  },
  mounted() {
    this.init();
  },
  data() { 
    return {
      // TO-DO:: DB에서 가져올 값
      menuList: [],
    }
  },
  methods: {
    async getMenuList() {
      return [
        { title: 'Home', url: '/Home', icon: 'user-secret', imageSize: 'sm'},
        { title: 'About', url: '/About', icon: 'user-secret', imageSize: 'sm'},
        { title: 'TodoList', url: '/todo/TodoList', icon: 'user-secret', imageSize: 'sm'},
      ];
    },
    async init() {
      this.menuList = await this.getMenuList();
    },
  }
}
</script>
<style>
  aside {
    position: relative;
    min-width: 200px;
    background-color: white;
  }
</style>