<template>
  <table :id="id">
    <colgroup>
      <col
        v-for="(h, hIdx) in header"
        :key="'__yDataTable__col__' + hIdx"
        :style="{ width: h.width }"
      />
    </colgroup>
    <thead>
      <th
       v-for="(h, hIdx) in header"
       :key="'__yDataTable__th__' + hIdx"
      >
        <td>
          {{ h.text }}
        </td>
      </th>
    </thead>
    <tbody>
      <tr 
        v-for="(d, dIdx) in data"
        :key="'__yDataTable__tr__' + dIdx"
      >
        <td
          v-for="(hd, hdIdx) in header"
          :key="'__yDataTable__td__' + hd.text + '__' + hdIdx"
        >
          <!-- -->
          <!-- icon -->
          <template
            v-if="hd.type == 'icon'"
          >
            <y-icon
              v-bind="{ ...hd.extensionProperties, ...convertComputedProperties(hd.compute, d) }"
            />
          </template>
          {{ d[hd.key] }}
        </td>
      </tr>
    </tbody>
  </table>
</template>
<script>
  import { computed, toRefs } from 'vue'
  export default {
    name: 'y-data-table',
    props: {
      id: {
        type: String,
        default: 'y-data-table',
      },
      header: {
        type: Array,
        default: () => []
      },
      data: {
        type: Array,
        default: () => []
      }
    },
    setup(props) {
      const { header, data } = toRefs(props);

      const convertComputedProperties = (computedProperties, data) => {
        return Object.keys(computedProperties).reduce((prev, key) => prev[key] = computed(() => computedProperties[key](data)), {});
      } 

      return {
        header,
        data,
        
        convertComputedProperties
      }
    }
  }
</script>

