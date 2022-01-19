<template>
  <!-- <y-header /> -->
  <section>
    <y-left-aside />
    <y-content>
      <router-view />
    </y-content>
  </section>
</template>
<script>
import YLeftAside from './modules/YLeftAside'
import YContent from './modules/YContent'
export default {
  name: 'y-layout',
  components: {
    // YHeader,
    YLeftAside,
    YContent,
  },  
  data() { return {}},
  mounted() {
  }
}
</script>
<style scoped>
  section {
    height: 100%;
    position: relative;
    display: flex;
    flex-grow: 1; 
    background-color: lightyellow;
  }

  article {
    padding: 10px;
  }

</style>