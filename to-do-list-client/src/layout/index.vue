<template>
  <!-- <y-header /> -->
  <section>
    <y-left-aside />
      <y-content>
      </y-content>
  </section>
</template>
<script>
import YLeftAside from './modules/YLeftAside'
import YContent from './modules/YContent'
export default {
  name: 'y-layout',
  components: {
    YLeftAside,
    YContent,
  },
  computed: {
    key() {
      return this.$route.path
    }
  },
  data() { return {
  }},
  mounted() {
  }
}
</script>
<style scoped>
  section {
    min-height: inherit;
    position: relative;
    display: flex;
    overflow-y: hidden;
    background-color: lightyellow;
  }

  article {
    padding: 10px;
  }

</style>