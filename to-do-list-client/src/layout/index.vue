<template>
  <!-- <y-header /> -->
  <section>
    <y-left-aside />
    <article>
      <slot></slot>
    </article>
  </section>
</template>
<script>
// import YHeader from './modules/YHeader'
import YLeftAside from './modules/YLeftAside'
export default {
  name: 'y-layout',
  components: {
    // YHeader,
    YLeftAside
  },  
  data() { return {}}
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