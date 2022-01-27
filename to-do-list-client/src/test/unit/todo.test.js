import { mount } from '@vue/test-utils'
import TodoList from '@/pages/todo/TodoList'

// Component
import YIcon from '@/components/common/YIcon';
import YButton from '@/components/common/YButton';
import YCard from '@/components/common/YCard';
import YEmptyList from '@/components/common/YEmptyList';
import YInput from '@/components/common/YInput';
import YModal from '@/components/common/YModal';

describe('todo-list component', () => {
  let wrapper;
  
  beforeEach(() => {
    wrapper = mount(TodoList, {
      global: {
        components: {
          'y-icon': YIcon,
          'y-button': YButton,
          'y-card': YCard,
          'y-empty-list': YEmptyList,
          'y-input': YInput,
          'y-modal': YModal,
        }
      },
      TodoList,
      // attachTo: '#app > div',
    })
  })

  test('1', () => {
    expect(wrapper.vm.inputValue).toBe('');
  });
})