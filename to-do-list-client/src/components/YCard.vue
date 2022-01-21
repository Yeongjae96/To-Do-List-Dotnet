<template>
  <div class="card">
    <div class="card__title">
      <slot name="title">title</slot>
    </div>
    <div class="card__content">
      <slot name="content">content</slot>
    </div>
    <div class="card__tail">
      <slot name="tail">tail</slot>
    </div>
  </div>
</template>

<script>
export default {
  name: 'y-card',
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
   .card {
    @include flexColumn($horizontal-align: flex-start, $vertical-align: flex-start);
    position: relative;
    width: 90%;
    height: 90%;
    margin: 0 auto;
    background-color: white;
    padding: 20px 20px 0px 20px;
    -webkit-box-shadow: 6px 4px 15px 4px rgba(0,0,0,0.5); 
    box-shadow: 6px 4px 15px 4px rgba(0,0,0,0.5);
    & > * {
      width: 100%;
    }

    /* title 부분 css */
    & .card__title {
      font-size: 1.5rem;
      font-weight: bold;
      margin-bottom: 20px;
      padding-bottom: 10px;
      border-bottom: 1px solid #413e3e;
    }

    /* content 부분 css */
    & .card__content {
      & > :slotted(*:not(:last-child)) {
        margin-bottom: 10px;
      }
    }

    /* tail 부분 css */
    & .card__tail {
      position: absolute;
      bottom: 10px;
    }
  }
</style>