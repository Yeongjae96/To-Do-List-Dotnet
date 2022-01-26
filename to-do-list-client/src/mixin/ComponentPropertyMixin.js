export default {
  props: {
    width: {
      type: String,
      default: '100%',
    },
    height: {
      type: String,
      default: '50px',
    },
    color: {
      type: String,
      default: 'black',
    },
    text: {
      type: String,
      default: '기본값'
    },
    backgroundColor: {
      type: String,
      default: 'inherit',
    }
  },
  computed: {
    computedStyle() {
      return {
        ...this.size,
        ...this.computedBackgroundColor,
      }
    },
    size() {
      return {
        width: typeof(this.width) == 'number' ? `${this.width}px` : this.width,
        height: typeof(this.height) == 'number' ? `${this.height}px` : this.height
      }
    },
    computedBackgroundColor() {
      return {
        backgroundColor: this.backgroundColor,
      }
    }
  }
}