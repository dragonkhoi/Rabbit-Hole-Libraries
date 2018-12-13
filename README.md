# Rabbit-Hole-Libraries
Rabbit Hole Libraries (RHL) is an extremely simple open source API for accelerating :rocket: mixed reality development. RHL was originally designed for [CS11: How to Make VR] (http://web.stanford.edu/class/cs11si/) to help students learn virtual reality design and development principles without too much overhead in Unity. RHL is maintained by [Rabbit Hole] (https://www.rabbitholevr.org/) - Stanford's :mortar_board: XR :eyeglasses: Community :family_man_woman_girl_girl: :family_man_girl_boy: :family_man_man_girl_girl:. RHL is focused on development for the Oculus platform. Rabbit Hole Libraries are developed using composition models, where every piece of code is extremely decomposed into tiny chunks.

## Interaction
One of the key aspects of RHL is simplifying interaction code. We want to be a jQuery-style library that makes interactions in XR super easy to implement.

### InputSystem
RHL has a dedicated set of input systems for various interactions, such as Ray-based (pointing at stuff), Proximity-based (colliding with and grabbing stuff), and global event interactions.

### Interactables
RHL also has a dedicated set of interactables that can be interacted with in various ways, such as Ray-based (being pointed at), Proximity-based (being collided with and grabbed), and global event interactions.

### RHInteractable
The base class for all interactables.
**Member Variables**
Accessibility | Type | Variable Name | Description
---------------|-----|---------|------------------
public | UnityEvent | InteractionResponse | Users can drag and drop functions here that will be called when the response is triggered
public | bool | InteractableOnAwake | Whether or not a user can interact with this object right away
protected | bool | CurrentlyInteractable | Whether or not a user can interact with this object right now

**Member Functions**
Accessibility | Type | Function Name | Description
---------------|-----|---------|------------------
public | virtual void | TriggerResponse() | This public function allows events to trigger the response. Each subclass can customize the functionality of this response.
public | void | InvokeInteraction() | Calls the user-specified function(s)

#### Ray Based Interactions
RHL supports ray-based interactions, including an object being pointed at, an object no longer being pointed at, and an object being pointed at AND trigger pulled while pointing. Most objects in a ray-based interaction should have a RayHit, RayExit, and RayTrigger script attached and respond giving the user feedback when they are successfully pointing at an object, no longer pointing at an object, and interacting with an object with the trigger (respectively).

##### RHInteractableRayHit
A subclass of RHInteractable. Attach to objects that will respond when pointed at.

##### RHInteractableRayExit
A subclass of RHInteractable. Attach to objects that will respond when no longer pointed at.

##### RHInteractableRayTrigger
A subclass of RHInteractable. Attach to objects that will respond when pointed at AND trigger pulled.

## Visuals
RHL has simple fonts and materials to get your project looking polished.

## Examples
RHL has example scenes that illustrate the usage of the library.

## Contribution Guidelines
To contribute to RHL, please create a branch and make small changes. Create pull requests, which will be reviewed and, if approved, merged into master.

### Decomposition
Following a composition model, RHL strives to break code into the smallest chunks possible. Thus, users can attach only the small, modular behaviors necessary to get their achieved result without sorting through tons of features and parameters. Make sure code written is getting properly decomposed.
[ ] Decompose `PropertyAdjuster.cs` into `ColorChanger.cs` and `SizeChanger.cs`.

### Namespaces
Respect the namespace convention of mirroring folder structure. For example, a script in RHL > Scripts > Interactables should have the namespace `RHL.Scripts.Interactables`
