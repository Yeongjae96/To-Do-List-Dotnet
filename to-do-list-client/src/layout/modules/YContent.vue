<template>
  <div id="content">
    <div id="content-header" class="d-none">
      <p class="content-header__text">
        Today ({{ currentDayString }})
      </p>
    </div>
    <div id="content-body">
      <router-view v-slot="{Component, route }">
        <transition name="fade-transform" mode="out-in">
          <div class="full-size" :key="route.name">
            <component :is="Component" />
          </div>
        </transition>
      </router-view>
    </div>
  </div>
</template>
<script>
export default {
  name: 'y-content',
  props: {
    
  },
  data() {
    return {
      currentDay: new Date(),
    };
  },
  computed: {
    currentDayString() {
      return `${this.currentDay.getFullYear()}. ${this.currentDay.getMonth()+1}. ${this.currentDay.getDate()}.`;
    },
    key() {
      return this.$router.path;
    }
  },
  methods: {
    cc(r) {
      console.log(r.name);
      return r.name;
    }
  }
}
</script>
<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  #content {
    @include flexColumn;
    width: 100%;
  }

  #content-header {
    @include flexRow;
    width: 100%;
    min-height: 70px;
    padding-bottom: 30px;
  }

  .content-header__text {
    color: $color-lilac;
    font-size: $size-large;
    font-weight: bold;
    width: 100%;
    text-align: center;
  }

  #content-body {
    padding: 30px;
    // height: 100%;  
    flex: 1;
  }

  .full-size {
    width: 100%;
    height: 100%;
  }
</style>