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
import YMenuList from '@/layout/components/YMenuList'
export default {
  name: 'y-left-aside',
  components: {
    YMenuList,
  },
  data() { 
    return {
      menuList: [
        { title: 'Home', url: '/Home', icon: 'user-secret', imageSize: 'sm'},
        { title: 'About', url: '/About', icon: 'user-secret', imageSize: 'sm'},
      ],
    }
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