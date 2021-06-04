import Enzyme, { shallow } from 'enzyme'
import Adapter from '@wojtekmaj/enzyme-adapter-react-17'
import { AppBar } from '@material-ui/core'
import CustomAppbar from '../components/appbar'

Enzyme.configure({ adapter: new Adapter() })

it('Appbar loads', () => {
  const wrapper = shallow(<CustomAppbar />)
  const exist = wrapper.find(AppBar).exists()
  expect(exist).toEqual(true)
})
